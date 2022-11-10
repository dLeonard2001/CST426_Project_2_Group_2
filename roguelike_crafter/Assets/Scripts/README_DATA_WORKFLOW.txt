Hello I'm making this document to better explain how data should be saved as a savefile. 
So in the game manager, or player manager, wherever there is data that needs to be saved 
there should be a public static PlayerData object. There should also be this code 

public static PlayerData getPlayerData() {
        return [NAME OF PLAYER DATA OBJECT];
}

Then in the dataManager class which I provide, within the saveData function
rename TestPlayerManger to the name of the Player Object that contains the Player Data.

I can add more data to the PlayerData class as needs be. I will be looking into better ways to make it
easier to add variables. 

