import 'package:flutter/material.dart';
import 'package:Latent/main.dart';

buildAppBar(BuildContext context, String name) {
  return AppBar(
    elevation: 0,
    automaticallyImplyLeading: false,
    backgroundColor: primaryColor,
    flexibleSpace: SafeArea(
      child: Container(
        padding: EdgeInsets.only(right: 16),
        child: Row(
          children: <Widget>[
            buildleadingActions(context),
            buildMemberStatus(name: name),
            buildActions(),
          ],
        ),
      ),
    ),
  );
}

buildMemberStatus({String name}) {
  return Expanded(
    child: GestureDetector(
      onTap: () {
        print("Profiline gidildi");
      },
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Text(
            name,
            style: TextStyle(
              color: secondaryColor,
              fontSize: 16,
              fontWeight: FontWeight.w600,
            ),
          ),
          SizedBox(
            height: 6,
          ),
          Text(
            "Çevrimiçi",
            style: TextStyle(color: secondaryColor, fontSize: 13),
          ),
        ],
      ),
    ),
  );
}

buildActions() {
  return Row(
    children: [
      Icon(
        Icons.call,
        color: secondaryColor,
        size: 30,
      ),
      SizedBox(
        width: 10,
      ),
      Icon(
        Icons.video_call,
        color: secondaryColor,
        size: 30,
      ),
      SizedBox(
        width: 10,
      ),
      Icon(
        Icons.more_vert,
        color: secondaryColor,
        size: 30,
      ),
    ],
  );
}

buildleadingActions(BuildContext context) {
  return Row(
    children: [
      IconButton(
        onPressed: () {
          Navigator.pop(context);
        },
        icon: Icon(
          Icons.arrow_back_ios_outlined,
          color: secondaryColor,
        ),
      ),
      SizedBox(
        width: 2,
      ),
      Icon(
        Icons.supervised_user_circle,
        size: 40,
        color: secondaryColor,
      ),
      SizedBox(
        width: 12,
      ),
    ],
  );
}
