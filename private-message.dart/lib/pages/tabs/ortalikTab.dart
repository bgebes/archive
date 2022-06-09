import 'package:Latent/main.dart';
import 'package:flutter/material.dart';

Widget buildOrtalikTab(BuildContext context) {
  double width = MediaQuery.of(context).size.width;
  double containerwidth = width * 0.2;
  return Center(
      child: ListView(
    padding: EdgeInsets.only(top: 10),
    children: <Widget>[
      Container(
        width: MediaQuery.of(context).size.width * 0.4,
        height: 170,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(20.0)),
            color: secondaryColor),
        child: ListView(
          children: [
            ListTile(
              leading: Icon(Icons.supervised_user_circle, color: primaryColor),
              title:
                  Text("Berkay Gebeş", style: TextStyle(color: primaryColor)),
            ),
            ListTile(
                title: Text(
              "Bu devirde bilgisayar toplanmaz!!!",
              style: TextStyle(color: primaryColor),
            )),
            Row(mainAxisAlignment: MainAxisAlignment.spaceAround, children: [
              FlatButton(
                onPressed: () {},
                child: Icon(Icons.bolt, color: primaryColor),
                color: secondaryColor,
                height: 40,
              ),
              FlatButton(
                onPressed: () {},
                child: Icon(
                  Icons.mode_comment_rounded,
                  color: primaryColor,
                ),
                color: secondaryColor,
              )
            ])
          ],
        ),
      ),
      SizedBox(height: 20),
      Container(
        width: MediaQuery.of(context).size.width * 0.4,
        height: 350,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(20.0)),
            color: secondaryColor),
        child: ListView(
          children: [
            ListTile(
              leading: Icon(Icons.supervised_user_circle, color: primaryColor),
              title: Text("Barış Müftüoğlu",
                  style: TextStyle(color: primaryColor)),
            ),
            ListTile(
                title: Text(
              "TEKNOFEST'e başvurduk. Yusuf Dinç öğretmenimize bu fırsatı bize verdiği için çok teşekkür borçluyum",
              style: TextStyle(color: primaryColor),
            )),
            Row(mainAxisAlignment: MainAxisAlignment.spaceAround, children: [
              FlatButton(
                onPressed: () {},
                child: Icon(Icons.bolt, color: primaryColor),
                color: secondaryColor,
                height: 40,
              ),
              FlatButton(
                onPressed: () {},
                child: Icon(
                  Icons.mode_comment_rounded,
                  color: primaryColor,
                ),
                color: secondaryColor,
              )
            ]),
            ListTile(
              leading: Icon(
                Icons.account_box_rounded,
                color: primaryColor,
              ),
              title: Text("Yusuf Berat", style: TextStyle(color: primaryColor)),
              subtitle: Text(
                "Umarım davet edilirsiniz :)",
                style: TextStyle(color: primaryColor),
              ),
            ),
            ListTile(
              leading: Icon(
                Icons.account_box_rounded,
                color: primaryColor,
              ),
              title: Text("Can Emence", style: TextStyle(color: primaryColor)),
              subtitle: Text(
                "Hayırlı olsun kraal",
                style: TextStyle(color: primaryColor),
              ),
            )
          ],
        ),
      ),
    ],
  ));
}
