import 'package:Latent/pages/screens/call/callSomeone.dart';
import 'package:flutter/material.dart';
import 'package:Latent/main.dart';

Offset _tapDownPosition;

Widget buildAramalarTab({BuildContext context, String name, String time}) {
  List<Widget> callHistories = [
    callHistory(
        context: context, name: 'Barış Müftüoğlu', time: '10 dakika önce'),
    callHistory(context: context, name: 'Berkay Gebeş', time: '5 dakika önce'),
    callHistory(context: context, name: 'Yusuf Hoca', time: '1 dakika önce'),
    callHistory(context: context, name: 'Can', time: '1 saat önce'),
    callHistory(context: context, name: 'Yusuf Berat', time: 'Az önce'),
  ];

  return ListView(
    children: callHistories,
  );
}

void call(BuildContext context, String name) {
  Navigator.push(
    context,
    MaterialPageRoute(builder: (context) => CallSomeone(name: name)),
  );
}

callHistory({BuildContext context, String name, String time}) {
  return GestureDetector(
    onTapDown: (TapDownDetails details) {
      _tapDownPosition = details.globalPosition;
    },
    child: callData(context: context, name: name, time: time),
  );
}

callData({BuildContext context, String name, String time}) {
  return ListTile(
      onTap: () async {
        call(context, name);
      },
      onLongPress: () async {
        RenderBox overlay = Overlay.of(context).context.findRenderObject();
        showMenu(
          items: <PopupMenuEntry>[
            PopupMenuItem(
              value: 'deneme',
              child: Text("Sil"),
            )
          ],
          context: context,
          position: RelativeRect.fromLTRB(
            _tapDownPosition.dx,
            _tapDownPosition.dy,
            overlay.size.width - _tapDownPosition.dx,
            overlay.size.height - _tapDownPosition.dy,
          ),
        );
      },
      leading: Icon(Icons.supervised_user_circle, color: secondaryColor),
      title: Text(name, style: TextStyle(color: secondaryColor)),
      subtitle: Text(
        time,
        style: TextStyle(color: secondaryColor),
      ),
      trailing: Wrap(
        children: [
          IconButton(
            icon: Icon(Icons.call, color: secondaryColor),
          ),
          IconButton(
            icon: Icon(Icons.videocam, color: secondaryColor),
          ),
        ],
      ));
}
