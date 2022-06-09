import 'package:Latent/pages/mores/mores.dart';
import 'package:Latent/pages/screens/splash/splashScreen.dart';
import 'package:Latent/pages/tabs/tabs.dart';
import 'package:flutter/material.dart';

bool darkMode = false;
Color primaryColor = darkMode ? Color(0xff07284a) : Color(0xffFFFFFF);
Color secondaryColor = darkMode ? Color(0xffFFFFFF) : Color(0xff07284a);

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: SplashScreen(),
      title: 'Private Message',
    );
  }
}

class AnaSayfa extends StatefulWidget {
  final List<Tab> navTabs = <Tab>[
    Tab(icon: Icon(Icons.camera_alt, color: secondaryColor)),
    Tab(
      child: Padding(
        padding: EdgeInsets.only(right: 20),
        child: Icon(Icons.explore, color: secondaryColor),
      ),
    ),
    Tab(
      child: Padding(
        padding: EdgeInsets.only(left: 20),
        child: Icon(Icons.message, color: secondaryColor),
      ),
    ),
    Tab(icon: Icon(Icons.call, color: secondaryColor)),
  ];

  List<CustomPopupMenu> dahaFazla = [
    CustomPopupMenu(title: 'Profil', mekan: Profile()),
    CustomPopupMenu(title: 'İzinler', mekan: Izinler()),
    CustomPopupMenu(title: 'Tercihler', mekan: Tercihler()),
    CustomPopupMenu(title: 'Bildirimler', mekan: Bildirimler()),
    CustomPopupMenu(title: 'Gizlilik', mekan: Gizlilik()),
    CustomPopupMenu(title: 'Yapımcılar', mekan: Yapimcilar()),
  ];

  TabController _tabController;
  int currentIndex = 0;
  CustomPopupMenu _selectedDahaFazla;

  @override
  State<StatefulWidget> createState() => _AnaSayfa();
}

class _AnaSayfa extends State<AnaSayfa> with SingleTickerProviderStateMixin {
  @override
  void initState() {
    widget._tabController =
        TabController(length: widget.navTabs.length, vsync: this, initialIndex: 2);
    widget._tabController.addListener(_handleTabSelection);
    super.initState();
  }

  @override
  void dispose() {
    widget._tabController.dispose();
    super.dispose();
  }

  void _handleTabSelection() {
    setState(() {
      widget.currentIndex = widget._tabController.index;
    });
  }

  void dahaFazla_git(StatefulWidget mekan) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => mekan),
    );
  }

  void dahaFazla_selected(CustomPopupMenu value) {
    setState(() {
      widget._selectedDahaFazla = value;
      dahaFazla_git(widget._selectedDahaFazla.mekan);
    });
  }

  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
      length: 4,
      child: Scaffold(
        floatingActionButtonLocation:
            FloatingActionButtonLocation.miniCenterDocked,
        appBar: AppBar(
          backgroundColor: primaryColor,
          title: Text('Latent', style: TextStyle(color: secondaryColor)),
          actions: <Widget>[
            IconButton(
                tooltip: 'Ara',
                icon: Icon(Icons.search, color: secondaryColor),
                onPressed: () {}),
            PopupMenuButton(
              child: IconButton(
                  icon: Icon(Icons.more_vert, color: secondaryColor)),
              elevation: 3.2,
              onSelected: dahaFazla_selected,
              tooltip: 'Daha Fazla',
              itemBuilder: (BuildContext context) {
                return widget.dahaFazla.map((element) {
                  return PopupMenuItem(
                    child: Text(element.title),
                    value: element,
                  );
                }).toList();
              },
            ),
          ],
        ),
        bottomNavigationBar: BottomAppBar(
            shape: CircularNotchedRectangle(),
            color: primaryColor,
            child: TabBar(
                controller: widget._tabController,
                tabs: widget.navTabs,
                indicatorColor: secondaryColor)),
        body: TabBarView(
          controller: widget._tabController,
          children: [
            CameraApp(),
            buildOrtalikTab(context),
            buildMesajlarTab(context),
            buildAramalarTab(context: context),
          ],
        ),
        floatingActionButton: buildfloatActionButton(widget.currentIndex),
        backgroundColor: primaryColor,
      ),
    );
  }

  Widget buildfloatActionButton(int index) {
    if (index == 0) {
      return null;
    }

    IconData floatIconData;
    switch (index) {
      case 1:
        floatIconData = Icons.explore;
        break;
      case 2:
        floatIconData = Icons.message;
        break;
      case 3:
        floatIconData = Icons.call;
        break;
    }

    return FloatingActionButton(
      heroTag: 'Bottom-Middle Button',
      child: Icon(floatIconData, color: primaryColor),
      backgroundColor: secondaryColor,
    );
  }
}

class CustomPopupMenu {
  CustomPopupMenu({this.title, this.mekan});

  String title;
  StatefulWidget mekan;
}
