import 'package:Latent/main.dart';
import 'package:Latent/main.dart';
import 'package:flutter/material.dart';
import 'parts/parts_appbar.dart';

Color ownMessageColor = Color(0xFF147df5);

class msgToSomeone extends StatefulWidget {
  String name;

  msgToSomeone({this.name: 'Berkay Gebeş'});

  List<Message> messages = [
    Message(message: 'Selam', from: 0, time: "00.00"),
    Message(message: 'Aleyküm selam', from: 1, time: "00.00"),
    Message(message: 'Nasılsın?', from: 1, time: "00.01"),
    Message(message: 'İyi sen?', from: 0, time: "00.01"),
    Message(
        message:
        'Sorma yaa işler çok kötü, herşey sıkıştı napıcam bilmiyorum öyle işte yaşıyoruz, öyle böyle',
        from: 0,
        time: "00.02"),
    Message(message: 'Hadi ya üzüldüm :/', from: 1, time: "00.02"),
    Message(
        message: 'Yardımcı olabileceğim birşey varmı acaba?',
        from: 1,
        time: "00.03"),
    Message(message: 'Yoktur teşekkür ederim :))', from: 0, time: "00.03"),
    Message(
        message: 'Ben teşekkür ederim keşke yardımcı olabilsem',
        from: 1,
        time: "00.04"),
    Message(message: 'Aa', from: 0, time: "00.05"),
  ];

  @override
  State<StatefulWidget> createState() => _msgToSomeone();
}

class _msgToSomeone extends State<msgToSomeone> {
  final sendTextBoxController = TextEditingController();
  final scrollController = ScrollController();
  int textBoxSize = 0;

  @override
  void dispose() {
    sendTextBoxController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: buildAppBar(context, widget.name),
      body: Container(
        color: primaryColor.withOpacity(0.1),
        child: Column(
          children: [
            buildMessagesList(),
            buildSendArea(),
          ],
        ),
      ),
    );
  }

  buildSendArea() {
    return Container(
      child: Padding(
        padding: EdgeInsets.only(left: 2, bottom: 3, top: 3),
        child: Row(
          children: <Widget>[
            buildMessageArea(),
            SizedBox(
              height: 50,
              child: sendButton(textBoxSize),
            ),
          ],
        ),
      ),
    );
  }

  buildMessageArea() {
    return Expanded(
      child: Container(
        height: 50,
        decoration: BoxDecoration(
          color: ownMessageColor.withOpacity(0.9),
          borderRadius: BorderRadius.all(Radius.circular(30)),
        ),
        child: Row(
          children: [
            Padding(
              padding: EdgeInsets.only(left: 10),
              child: Icon(Icons.emoji_emotions_outlined,
                  size: 25, color: primaryColor),
            ),
            buildSendTextBox(),
            Icon(Icons.attach_file_outlined, size: 25, color: primaryColor),
            Padding(
              padding: EdgeInsets.only(right: 10),
              child: Icon(Icons.camera_alt, size: 25, color: primaryColor),
            ),
          ],
        ),
      ),
    );
  }

  buildSendTextBox() {
    return Expanded(
      child: Scrollbar(
        child: TextField(
          style: TextStyle(color: primaryColor),
          onChanged: (text) {
            setState(() {
              textBoxSize = text
                  .trim()
                  .length;
            });
          },
          controller: sendTextBoxController,
          cursorColor: primaryColor,
          keyboardType: TextInputType.multiline,
          maxLines: null,
          decoration: InputDecoration(
            border: InputBorder.none,
            contentPadding:
            EdgeInsets.only(top: 2.0, left: 6, right: 6, bottom: 2.0),
            hintText: "Mesajınızı girin...",
            hintStyle: TextStyle(
              color: primaryColor,
            ),
          ),
        ),
      ),
    );
  }

  buildMessagesList() {
    return Expanded(
      child: Container(
        child: SingleChildScrollView(
          reverse: true,
          controller: scrollController,
          padding: EdgeInsets.all(5),
          child: MessageContainer(messageList: widget.messages),
        ),
      ),
    );
  }

  MessageContainer({List<Message> messageList}) {
    List<Widget> messageContainers = new List<Widget>();

    for (Message msg in messageList) {
      messageContainers
          .add(buildMessageContainer(msg.message, msg.from, msg.time));
    }

    return Column(
      children: messageContainers,
    );
  }

  buildSpace(bool check) {
    Widget space = check ? Spacer() : SizedBox();

    return space;
  }

  buildMessageContainer(String metin, int kimden, String zaman) {
    bool check1 = kimden == 0 ? true : false;
    bool check2 = kimden == 0 ? false : true;
    Color containerColor = kimden == 0 ? ownMessageColor : ownMessageColor.withOpacity(0.75);

    return Row(
      children: [
        buildSpace(check1),
        Padding(
          padding: EdgeInsets.all(3),
          child: Container(
            decoration: BoxDecoration(
              color: containerColor,
              borderRadius: BorderRadius.all(Radius.circular(10)),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                contentMessage(metin),
                buildMessageInfo(zaman: zaman),
              ],
            ),
          ),
        ),
        buildSpace(check2),
      ],
    );
  }

  contentMessage(String metin) {
    return Padding(
      padding: EdgeInsets.only(top: 10, left: 10, right: 10),
      child: Container(
        constraints: BoxConstraints(minWidth: 40, maxWidth: 175),
        child: Text(
          metin,
          style: TextStyle(color: Colors.white, fontSize: 15),
        ),
      ),
    );
  }

  buildMessageInfo({String zaman: '00.00',
    IconData infoIcon: Icons.done_all,
    Color infoColor: const Color(0xFFfee440)}) {
    return Container(
      padding: EdgeInsets.only(right: 5),
      child: Row(
        children: [
          Text(zaman, style: TextStyle(color: primaryColor, fontSize: 10)),
          Icon(
            infoIcon,
            size: 17,
            color: infoColor,
          ),
        ],
      ),
    );
  }

  sendButton(int size) {
    Icon temp_Icon = size > 0 ? Icon(Icons.message) : Icon(Icons.mic);
    temp_Function() {
      if (size > 0) {
        sendMessage(message: sendTextBoxController.text);
      } else {
        sendAudio();
      }
    }

    return FloatingActionButton(
      backgroundColor: ownMessageColor,
      heroTag: 'sendButtonText',
      child: temp_Icon,
      onPressed: temp_Function,
    );
  }

  sendMessage({String message: 'deneme'}) {
    message = message.trim();
    var zaman = DateTime.now(),
        saat = zaman.hour,
        dakika = zaman.minute;
    String teslim_zamani = "${saat}.${dakika}";

    setState(() {
      widget.messages
          .add(Message(message: message, from: 0, time: teslim_zamani));
      sendTextBoxController.text = '';
      textBoxSize = 0;
    });
    scrollController.animateTo(0.0,
        duration: Duration(milliseconds: 300), curve: Curves.easeOut);
  }

  sendAudio() {
    print('ses deneme bir iki');
  }
}

class Message {
  String message, time;
  int from;

  Message({this.message, this.time, this.from});
}
