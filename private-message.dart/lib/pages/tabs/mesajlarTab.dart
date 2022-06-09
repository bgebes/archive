import 'package:Latent/pages/screens/message/msgToSomeone.dart';
import 'package:flutter/material.dart';
import 'package:Latent/main.dart';

Offset _tapDownPosition;
Color longPressBottomColor = darkMode == true ? secondaryColor : primaryColor;

List<Widget> longPressButtoms = [
  IconButton(
    icon: Icon(
      Icons.inbox,
      color: longPressBottomColor,
    ),
  ),
  IconButton(
      icon: Icon(
    Icons.delete,
    color: longPressBottomColor,
  )),
  IconButton(
      icon: Icon(
    Icons.volume_off,
    color: longPressBottomColor,
  )),
  IconButton(
      icon: Icon(
    Icons.attach_file,
    color: longPressBottomColor,
  )),
];

List<Widget> pinnedUsers = [
  IconButton(icon: Icon(Icons.account_circle, color: secondaryColor)),
  IconButton(icon: Icon(Icons.account_circle, color: secondaryColor)),
];

Widget buildMesajlarTab(BuildContext context) {
  List<Widget> messagesHistories = [
    Container(
        margin: EdgeInsets.only(top: 5),
        width: double.infinity,
        height: 50,
        child:
            ListView(scrollDirection: Axis.horizontal, children: pinnedUsers)),
    msgSection(
      context: context,
      userName: 'Berkay Gebeş',
      lastMessage: 'Nasılsın ya reis',
      done: 2,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Barış Müftüoğlu',
      lastMessage: 'Futbolcu reis',
      done: 1,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Yusuf Hoca',
      lastMessage: 'Hocam, nasılsınız?',
      done: 0,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Can',
      lastMessage: 'Halı saha?',
      done: 2,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Yusuf Berat',
      lastMessage: 'Video edit hazır mı dostum?',
      done: 2,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Berkay Tikenoğlu',
      lastMessage: 'Adaşımm',
      done: 1,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Öncü',
      lastMessage: 'Döneriniz harika',
      done: 1,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Fatsa Hünkar',
      lastMessage: '10 Lahmacun 3 ü Acısız',
      done: 1,
      volume: 0,
    ),
    msgSection(
      context: context,
      userName: 'Telefon Sapığı',
      lastMessage: 'Bırak peşimiii',
      done: 2,
      volume: 0,
    ),
  ];

  return ListView(
    children: messagesHistories,
  );
}

msgSection({
  BuildContext context,
  String userName,
  String lastMessage,
  int done,
  int volume,
}) {
  return GestureDetector(
    onTapDown: (TapDownDetails details) {
      _tapDownPosition = details.globalPosition;
    },
    child: msgContent(
      context: context,
      userName: userName,
      lastMessage: lastMessage,
      done: done,
      volume: volume,
    ),
  );
}

goToMessageWithUser({BuildContext context, String name}) {
  Navigator.push(
    context,
    MaterialPageRoute(builder: (context) => msgToSomeone(name: name)),
  );
}

msgContent({
  BuildContext context,
  String userName,
  String lastMessage,
  int done,
  int volume,
}) {
  Color doneColor = secondaryColor;
  IconData volumeStatus = volume == 0 ? null : Icons.volume_off;

  IconData doneStatus;
  switch (done) {
    case 0:
      doneStatus = Icons.done;
      break;
    case 1:
      doneStatus = Icons.done_all;
      break;
    case 2:
      doneStatus = Icons.done_all;
      doneColor = Colors.blue;
      break;
  }

  return ListTile(
    onTap: () async {
      goToMessageWithUser(context: context, name: userName);
    },
    onLongPress: () async {
      RenderBox overlay = Overlay.of(context).context.findRenderObject();
      showMenu(
        items: <PopupMenuEntry>[
          PopupMenuItem(
              value: null,
              child: Container(
                width: MediaQuery.of(context).size.width,
                height: 50,
                child: Wrap(
                  spacing: 15,
                  children: longPressButtoms,
                ),
              )),
        ],
        context: context,
        position: RelativeRect.fromLTRB(
          _tapDownPosition.dx,
          _tapDownPosition.dy,
          overlay.size.width - _tapDownPosition.dx,
          overlay.size.height - _tapDownPosition.dy,
        ),
        color: Colors.transparent,
      );
    },
    leading: Icon(Icons.supervised_user_circle, color: secondaryColor),
    title: Text(
      userName,
      style: TextStyle(color: secondaryColor),
    ),
    subtitle: Row(
      children: [
        Icon(doneStatus, color: doneColor),
        Text(
          lastMessage,
          style: TextStyle(color: secondaryColor),
        ),
      ],
    ),
    trailing: Icon(volumeStatus, color: secondaryColor),
  );
}
