import 'package:Latent/main.dart';
import 'package:animated_splash_screen/animated_splash_screen.dart';
import 'package:flutter/material.dart';
import 'package:page_transition/page_transition.dart';

class SplashScreen extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _SplashScreen();
}

class _SplashScreen extends State<SplashScreen> {
  @override
  Widget build(BuildContext context) {
    return AnimatedSplashScreen(
      splash: 'assets/icon.png',
      nextScreen: AnaSayfa(),
      splashTransition: SplashTransition.sizeTransition,
      pageTransitionType: PageTransitionType.leftToRight,
    );
  }
}