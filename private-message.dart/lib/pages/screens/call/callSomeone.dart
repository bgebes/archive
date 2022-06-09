import 'package:Latent/main.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class CallSomeone extends StatefulWidget {
  String name;

  CallSomeone({this.name});

  @override
  State<StatefulWidget> createState() => _CallSomeOne();
}

class _CallSomeOne extends State<CallSomeone> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        color: primaryColor,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            MemberInfo(),
            CallInfos(),
            CallActions(),
          ],
        ),
      ),
    );
  }

  MemberInfo() {
    return Container(
      child: Column(
        children: [
          Icon(Icons.account_box, size: 200, color: secondaryColor),
          Text(
            widget.name,
            style: TextStyle(
                color: secondaryColor,
                fontWeight: FontWeight.bold,
                fontSize: 25),
          ),
        ],
      ),
    );
  }

  CallInfos() {
    return Container(
      padding: EdgeInsets.only(top: 50),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            'Konuşma süresiniz: 1 saat 45 dakika',
            style: TextStyle(color: secondaryColor, fontSize: 17),
          ),
          SizedBox(width: 10),
          Icon(Icons.security, color: Colors.green),
        ],
      ),
    );
  }

  CallActions() {
    return Container(
      padding: EdgeInsets.only(top: 50),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          FloatingActionButton(
            heroTag: 'Video Call',
            backgroundColor: Color.fromARGB(220, 0, 255, 0),
            child: Icon(Icons.video_call, color: primaryColor),
          ),
          SizedBox(width: 10),
          FloatingActionButton(
            heroTag: 'Mic Off',
            backgroundColor: Colors.yellow,
            child: Icon(Icons.mic_off, color: primaryColor),
          ),
          SizedBox(width: 10),
          FloatingActionButton(
            onPressed: (){
              Navigator.pop(context);
            },
            heroTag: 'Call End',
            backgroundColor: Color.fromARGB(220, 255, 0, 0),
            child: Icon(Icons.call_end, color: primaryColor),
          ),
        ],
      ),
    );
  }
}
