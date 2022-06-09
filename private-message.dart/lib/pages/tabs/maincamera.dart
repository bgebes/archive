import 'package:Latent/main.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'cameraTab.dart';

void main() => runApp(CameraApp());

class CameraApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    SystemChrome.setSystemUIOverlayStyle(SystemUiOverlayStyle(
      statusBarColor: primaryColor,
    ));
    return MaterialApp(
      theme: ThemeData(
        primaryColor: primaryColor,
      ),
      debugShowCheckedModeBanner: false,
      home: CameraScreen(),
    );
  }
}
