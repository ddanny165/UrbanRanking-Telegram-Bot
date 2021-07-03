# UrbanRanking Telegram Bot
UI interface for a [coursework Web API](https://github.com/ddanny165/UrbanRankingApi) (Telegram Bot) using C#
## Table of Contents
- [About](https://github.com/ddanny165/UrbanRankingTelegBot#about)
- [Product functions](https://github.com/ddanny165/UrbanRankingTelegBot#product-functions)
- [How does it actually work?](https://github.com/ddanny165/UrbanRankingTelegBot#how-does-it-actually-work)
- [User guide on how to use this bot](https://github.com/ddanny165/UrbanRankingTelegBot#user-guide-on-how-to-use-this-bot)

## About
UrbanRanking bot can be a useful tool to get at least a basic image of living standards in different big cities and the most popular tourist destinations in various key areas that affect our daily lives. Quickly and without a significant need to leave a messenger.

## Product functions
- **Get a list of available cities**

- **Get a detailed review on one of the cities just by typing the city name and sending it to the bot.**

Examples of the city rating categories: Housing, Cost of Living, Safety, Travel Connectivity, Education, Internet Access, Healthcare, Internet Access, Environmental Quality, and so on. (all the data is taken from public API's - teleport.org && rapidapi.com). In addition to assessing the city by criteria, it is also provided to display some general description that summarizes all the points of the city's rating.

- **Everytime when a user requests a review on one of the available cities, bot automatically saves the city name to the saved list.**

There is also an opportunity to view a saved list (every user has its own list), modify it (clear it all or delete a single unit).

- **Subscribe to get a daily review on a random city daily**
- **Unsubscribe from getting a review on a random city daily**

## How does it actually work?
![architecture](https://github.com/ddanny165/pictures/blob/main/arc.jpg)

The user interacts with the product through the UI interface (telegram bot). The user enters a command and depending on the entered text, refers to one of the Rest methods of my own [WEB API](https://github.com/ddanny165/UrbanRankingApi), which interacts with [DynamoDB database on cloud](https://aws.amazon.com/dynamodb/) and two other public API's to obtain additional information, required for this product.

  The [WEB API](https://github.com/ddanny165/UrbanRankingApi) has 12 HTTP methods, including 7 GET, 2 POST and 3 DELETE. They are placed in the following two controllers: [CitiesController](https://github.com/ddanny165/UrbanRankingApi/blob/main/UrbanRankingAPI/Controllers/CitiesController.cs) and [UsersController](https://github.com/ddanny165/UrbanRankingApi/blob/main/UrbanRankingAPI/Controllers/UsersController.cs).

  CitiesController includes three GET methods for working with public API's and two other methods for working with data taken from the database, which does not require authorization. UsersController includes 2 GET, 2 POST and 3 DELETE methods, this controller is used only for working with the database.
  
## User guide on how to use this bot

When user launches this bot for the first time, telegram automatically sends the ***/start*** command. Bot processes the given command, greets the new user and offers him to use the ***/botguide*** command to get detailed instructions on how to use this bot.

![/start](https://github.com/ddanny165/pictures/blob/main/ins1.jpg)

After entering the ***/botguide*** command, bot sends the instruction for use to user. 

![/botguide](https://github.com/ddanny165/pictures/blob/main/imageedit_1_9738707193.png)



- To get a city review **all you have to do is to type in a city name and send it to the bot**, letter's case is not important. **Bot automatically saves the name of the city which you were looking for.** 

![CityReview](https://github.com/ddanny165/pictures/blob/main/photo_2021-07-03_17-47-09.jpg)



- If a user is not sure that the city for which he plans to get a review is present in our database - there is a command ***/getavailable + letter***, it returns the names of all the cities which are present in my service and which start with the letter specified by the user.

![PresentCities](https://github.com/ddanny165/pictures/blob/main/ins6.jpg)



- All the names of cities for which a user received a review are stored in the database. Each user has their own list. The ***/getsavedlist*** command helps you to get your own list of all saved cities.

![/GETSAVEDLIST](https://github.com/ddanny165/pictures/blob/main/ins7.jpg)



- With a help of ***/delete*** command you can delete one of the cities from the list.

![/DELETE](https://github.com/ddanny165/pictures/blob/main/ins8.jpg)



- In addition, there is also a command to completely clear a list of saved cities - ***/clearlist***.

![/CLEARLIST](https://github.com/ddanny165/pictures/blob/main/ins9.jpg)



- A user also has an opportunity to receive a list of the best cities for some evaluation categories. Such categories are businessfreedom, costofliving, housing, leisure & culture, safety, taxation, travelconnectivity. This is all done with the ***/getbest + category name*** command.

![/GETBEST](https://github.com/ddanny165/pictures/blob/main/ins10.jpg)


- In addition, a user also has the opportunity to subscribe in order to get a review on a random city daily. It is possible to do with the ***/subscribe*** command.

![/SUBSCRIBE](https://github.com/ddanny165/pictures/blob/main/ins11.jpg)



- Moreover, to unsubscribe from getting a review on a random city daily - all you have to do is to send the bot a command ***/unsubscribe***.

![/UNSUBSCRIBE](https://github.com/ddanny165/pictures/blob/main/ins12.jpg)

The bot sends a user the message about the successful unsubscription and removes a user's id from the database.
