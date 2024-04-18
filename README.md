# Details about the project.

•	GitHub Link: https://github.com/iAmSidh108/Card_Game

•	Showcase Video (YouTube) Link: https://youtu.be/0IBlwNQw6jw

•	Drive Link with all the files: https://drive.google.com/drive/folders/1oEFfKMwKYzmDBgnq89n7xKdIOVX9UC0U?usp=sharing

## Read this before opening the project:

•	It is a 2D URP project with version 2022.3.20f1

•	The game is in scene named MainScene.

•	When play is clicked, you will see a play button. Click on the button to start the game and spawn the cards.

•	What card will be spawned is not hardcoded, it is being loaded using json file that is provided. I am parsing the Json file and then comparing the string from json and total sprites provided. I am only spawning the matching cards equivalent to json string. You can match that.

•	The json parsing and spawning is don in a separate script called JSONHandler. 

•	For the card mechanics, I have tried implementing MVC Pattern (There are 3 main scripts CardView, CardManager, InputManager).

•	I might update the code even after submission, so for updated code, please check the GitHub link provided above.

•	 When play button clicked, cards are spawned horizontally as per the json file.

•	You can select multiple cards, when selected cards color changes to blue shade. That way you can know which cards are selected.

•	As soon as more than one card is selected the group button appears on the bottom right corner of the canvas.

•	You can drag and drop cards from anywhere to anywhere, one group to another available group (only available groups).

•	When there are zero cards under a group, the group disappears.

•	For groups I have set 5 different location in the scene where the cards are grouped.

•	If there are no groups available and you try to create a group, you get a popup telling no more groups available.

•	I have tried my best to make UI look good as possible.

![1](https://github.com/iAmSidh108/Card_Game/assets/63715240/5f32cd11-897e-4889-868b-ee79a863128c)

![5](https://github.com/iAmSidh108/Card_Game/assets/63715240/ef99dece-d141-464f-9195-0f7f609848f3)

![4](https://github.com/iAmSidh108/Card_Game/assets/63715240/7eeccf8d-e9e2-486c-b79d-79a8bfec26de)

![3](https://github.com/iAmSidh108/Card_Game/assets/63715240/5de0c345-3ec5-475d-a555-851e199955a3)

![2](https://github.com/iAmSidh108/Card_Game/assets/63715240/73c9594c-001a-4dac-a476-e58fbebc9a70)

![6](https://github.com/iAmSidh108/Card_Game/assets/63715240/32a76312-5df9-41f1-bcf8-ae936134bdd8)


