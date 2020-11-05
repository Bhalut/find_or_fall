![cover](./pictures/cover.png?raw=true "Cover")

# Find or Fall

'Find or Fall' is a casual, online, turn-based video game for Android devices, where two persons must guess which is the button that makes their opponent fall, they have a the same board with eight buttons so it's possible to make yourself fall, the game ends when someone falls.

Our purpose with this game is to make people laugh, through that special feeling of beating someone in a game of luck, like rock-paper-scissors.

### Links

- Download link (Playstore):
https://play.google.com/store/apps/details?id=com.DeamonGames.FindOrFall

- Landing Page:
https://monicajoa.github.io/findorfalllandingpage/

- Backend Github:
https://github.com/KaroDev3/backend-find_or_fall

### Technologies

![technologies](./pictures/technologies.png?raw=true "Technologies")

### Screenshots

![screenshots](./pictures/screenshots.png?raw=true "Screenshots")

### Unity version

2019.4.11f1

### Run the game

Open the scene 'opening', and press the play button of the editor.

### Scripts ('Assests/Scripts')

- AudioManager.cs: Turns the audio on or off.
- Background.cs: Moves the background image smoothly on x axis.
- ButtonManager.cs: Handles the scene events when a button is pressed.
- Connection.cs: Handles the web socket events.
- EmmitPlayerTurn.cs: Handles the "send turn" web socket event.
- EndGame.cs: Displays the end game screen.
- Loader.cs: Handles the scene management.
- OpponentDisconnected.cs: Displays the opponent disconnected screen.
- TurnManager.cs: Handles the game logic.
- Username.cs: Diplays the user names.

### Scenes ('Assests/Scenes')

- Opening: Displays the splashscreen.
- Menu: Displays the button to start the game and a settings button.
- Main: The game scene.

### Socket.io ('Assests/SocketIO')

This is s a free library: [Socket.IO for Unity](https://assetstore.unity.com/packages/tools/network/socket-io-for-unity-21721).

With this library we can easily connect to the backend using the web socket protocol.

Here a [video tutorial](https://www.youtube.com/watch?v=J0udhTJwR88&t=1104s&ab_channel=AlexHicks) to learn how to use it.

### Infrastructure



### Team

- Nicolas Quinchia, Unity Developer (Gameplay) / Graphic designer.
- Mónica Ortiz, Backend / UI designer.
- Diana Quintero, Backend.
- Eddy Zapata, Unity Developer (Gameplay).
- Abdel Mejía, Unity Developer.

