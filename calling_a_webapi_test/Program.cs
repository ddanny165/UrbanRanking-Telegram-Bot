using System;
using System.Threading.Tasks;
using UrbanRankingTelegBot.Services;
using UrbanRankingTelegBot.AddLogic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;


namespace UrbanRankingTelegBot
{
    class Program
    {
        static TelegramBotClient client;
        static readonly string token = Constants.TelegramBotToken;

        static readonly WebApiService webapiservice = new();
  
        static async Task Main(string[] args)
        {
            WebApiService.httpClient.BaseAddress = new Uri(Constants.WebApiAdress);
            WebApiService.httpClient.DefaultRequestHeaders.Add("ApiKey", Constants.ApiKey);

            client = new TelegramBotClient(token) 
            {Timeout = TimeSpan.FromSeconds(10)};

            while (true)
            {
                client.StartReceiving();
                client.OnMessage += OnMessageHandler;
                await SubscriptionSending();
                Console.ReadLine();
                client.StopReceiving();
            }
        }

        //subscription method
        private static async Task SubscriptionSending()
        {
            Random ran = new();
            int RandomNum;

            string RandomCity;
            string WebApiResult;

            while (true)
            {
                var dbChatIds = await webapiservice.GetSubscribeData();
                RandomNum = ran.Next(1, 137);

                RandomCity = AddLogicMethods.GettingRandomCity(RandomNum);
                WebApiResult = "📝[Subscription]\nDaily random city:\n\n" + webapiservice.GetCityReview
                    (RandomCity, 01).Result;

                foreach (var ChatId in dbChatIds)
                {
                    try
                    {
                        await client.SendTextMessageAsync(ChatId, WebApiResult);
                    }
                    catch (Telegram.Bot.Exceptions.ApiRequestException)
                    {
                        await webapiservice.DeleteSubscription(ChatId);
                        await SubscriptionSending();
                    }
                }

                Console.WriteLine("Daily message was sent to subscribers.\n");
                await Task.Delay(86400000); //delay 24 hours in milliseconds (86400000)
            }         
        }

        //handling bot's commands
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            try
            {
                
                var message = e.Message;

                if (message.Type == MessageType.Text)
                {
                    string Input = message.Text;

                    bool IsACity = AddLogicMethods.CheckingIfACity(Input);

                    string GetBestInput = "/getbest";
                    string GetAvailableInput = "/getavailable";
                    string DeleteInput = "/delete";

                    string CityToDelete;

                    Console.WriteLine($"A new message with text: {message.Text}, " +
                            $"username: @{message.From.Username}, userid {message.Chat.Id}.\n");

                    if (IsACity)
                    {
                        string WebApiResult = webapiservice.GetCityReview
                        ($"{message.Text}".ToLower(), message.From.Id).Result;

                        await client.SendTextMessageAsync
                            (message.Chat.Id, WebApiResult,
                            replyToMessageId: message.MessageId);
                    }

                    else if (message.Text.StartsWith(DeleteInput))
                    {
                        int InputStringLength = message.Text.Length;
                        string OutputInfo;

                        CityToDelete = message.Text.
                            Substring(7, InputStringLength - 7).ToLower();

                        bool IsACityToDelete = AddLogicMethods.CheckingIfACity(CityToDelete);

                        if (IsACityToDelete == false)
                        {
                            CityToDelete = AddLogicMethods.RemovingSpacesFromString(CityToDelete);
                        }

                        await webapiservice.Delete
                            (message.From.Id, CityToDelete);

                        bool IsACityCheck = AddLogicMethods.CheckingIfACity(CityToDelete);
                        if (IsACityCheck)
                        {
                            OutputInfo = "Successfully deleted.";
                        }
                        else
                        {
                            OutputInfo = "Unknown name of a city to delete.";
                        }

                        await client.SendTextMessageAsync
                            (message.Chat.Id, OutputInfo,
                            replyToMessageId: message.MessageId);
                    }

                    else if (message.Text.StartsWith(GetBestInput))
                    {
                        int InputStringLength = message.Text.Length;

                        string Category = message.Text.
                            Substring(8, InputStringLength - 8).ToLower();

                        Category = AddLogicMethods.RemovingSpacesFromString(Category);

                        bool IsACategory = AddLogicMethods.CheckingIfAvailableCategory(Category);

                        string Output;

                        if (IsACategory)
                        {
                            Output = webapiservice.GetBestByCategory(Category).Result;
                        }
                        else
                        {
                            Output = "No data available for the given category.";
                        }

                        await client.SendTextMessageAsync
                                (message.Chat.Id, Output,
                                replyToMessageId: message.MessageId);
                    }

                    else if (message.Text.StartsWith(GetAvailableInput))
                    {
                        int InputStringLength = message.Text.Length;

                        string Category = message.Text.
                            Substring(13, InputStringLength - 13).ToLower();

                        Category = AddLogicMethods.RemovingSpacesFromString(Category);

                        string Output;


                        Output = webapiservice.GetAvailableCities(Category).Result;

                        if (Output == null)
                        {
                            Output = "Wrong input.";
                        }

                        await client.SendTextMessageAsync
                                (message.Chat.Id, Output,
                                replyToMessageId: message.MessageId);
                    }

                    else
                    {
                        string SavedCitiesList;

                        switch (message.Text)
                        {
                            case "/start":
                                string WelcomeOutput = $"Welcome, {message.From.FirstName}!\n\n" +
                                    "/botguide command to get the instructions on how to use this bot.";

                                await client.SendTextMessageAsync
                                    (message.Chat.Id, WelcomeOutput,
                                    replyToMessageId: message.MessageId);
                                break;

                            case "/botguide":
                                string Guide = "📍To get a review on some city, all you have to do is " +
                                    "just type in a city name and send it to the bot. The bot automatically " +
                                    "saves the cities you looked for to the saved list.\n\n📍But what to do if you " +
                                    "are not sure if your city is available?\n\n/getavailable + letter - To get " +
                                    "available cities starting with the given letter.\n(example: /getavailable a)\n\n" +
                                    "📍What if I want to look at my list of saved cities?\n\n/getsavedlist command will help " +
                                    "you!\n\n📍Hmm... There are some cities I would love to delete from the list! How can" +
                                    " I do that?\n\n/delete + CityName - To delete one of the cities from the saved list.\n" +
                                    "(example: /delete Lviv)\n\n📍But what if there are a lot of cities on my list and it would " +
                                    "take a long time to delete them all?\n\n/clearlist - To clear your whole list.\n\n📍Is there " +
                                    "any possibility to get the list of the cities best by categories?\n\n/getbest + CategoryName " +
                                    "command will help you!\n(example: /getbest leisure&culture).\n\nSupported categories for this " +
                                    "command are businessfreedom, costofliving, housing, leisure&culture, safety, taxation, " +
                                    "travelconnectivity.\n\n📍Moreover, there is an opportunity for you to subscribe for getting an " +
                                    "information about a random city daily! How can you do that?\n/subscribe command will help you!\n\n" +
                                    "📍In case, if you want to unsubscribe\n/unsubscribe - to get unsubscribed from daily mailing." +
                                    "\n\n💫Hope you'll enjoy it!";

                                await client.SendTextMessageAsync
                                    (message.Chat.Id, Guide,
                                    replyToMessageId: message.MessageId);
                                break;

                            case "/getsavedlist":
                                try
                                {
                                    SavedCitiesList = await webapiservice.GetSavedCitiesList(message.From.Id);
                                }
                                catch (ArgumentNullException)
                                {
                                    SavedCitiesList = "Your list of saved cities is empty for now.";
                                }

                                await client.SendTextMessageAsync
                                (message.Chat.Id, SavedCitiesList,
                                    replyToMessageId: message.MessageId);
                                break;

                            case "/clearlist":
                                await webapiservice.DeleteAll(message.From.Id);

                                await client.SendTextMessageAsync
                                    (message.Chat.Id, $"Successfully cleared!",
                                    replyToMessageId: message.MessageId);
                                break;

                            case "/subscribe":
                                await webapiservice.PostSubDetails(message.From.Id);

                                await client.SendTextMessageAsync
                                    (message.Chat.Id, "Successfully subscribed!",
                                    replyToMessageId: message.MessageId);
                                break;

                            case "/unsubscribe":
                                await webapiservice.DeleteSubscription(message.From.Id);

                                await client.SendTextMessageAsync
                                    (message.Chat.Id, "Successfully unsubscribed!",
                                    replyToMessageId: message.MessageId);
                                break;

                            default:
                                await client.SendTextMessageAsync
                                    (message.Chat.Id, "Unknown command.",
                                    replyToMessageId: message.MessageId);
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unallowed message type was handled by bot.\n");
                    await client.SendTextMessageAsync
                                    (message.Chat.Id, "Unknown command.",
                                    replyToMessageId: message.MessageId);
                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
