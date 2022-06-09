import 'package:Latent/main.dart';
import 'package:flutter/material.dart';

class Profile extends StatefulWidget {
  bool isSwitched = false;

  @override
  State<StatefulWidget> createState() => _Profile();
}

class _Profile extends State<Profile> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: primaryColor,
      body: Container(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Column(
              children: [
                profilePhoto(),
                userName(),
              ],
            ),
            informations(),
          ],
        ),
      ),
    );
  }

  profilePhoto() {
    return Container(
      padding: EdgeInsets.all(7),
      decoration: BoxDecoration(shape: BoxShape.circle),
      child: CircleAvatar(
        radius: 65,
        backgroundImage: NetworkImage(
            'https://avatars.githubusercontent.com/u/72809874?v=4'),
      ),
    );
  }

  userName() {
    return Container(
      child: Text(
        'Berkay Gebeş',
        style: TextStyle(fontSize: 20),
      ),
    );
  }

  informations() {
    return Container(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          buildInfoOption(
              optionTitle: 'Anlık Durum',
              optionIcon: Icons.star,
              option: Switch(
                onChanged: toggleSwitch,
                value: widget.isSwitched,
                activeColor: Colors.green,
                inactiveThumbColor: Colors.redAccent,
              )),
          buildInfoOption(
              optionTitle: 'Telefon',
              optionIcon: Icons.phone_android,
              option: Text('+90 536 707 39 31')),
          buildInfoOption(
              optionTitle: 'Kullanıcı Adı',
              optionIcon: Icons.person,
              option: Text('Myth')),
        ],
      ),
    );
  }

  Widget buildInfoOption(
      {String optionTitle, IconData optionIcon, Widget option}) {
    return ListTile(
      title: Text(optionTitle),
      leading: Icon(optionIcon),
      trailing: option,
    );
  }

  void toggleSwitch(bool value) {
    setState(() {
      widget.isSwitched = widget.isSwitched ? false : true;
      print(widget.isSwitched.toString());
    });
  }
}
