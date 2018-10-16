# DiscordPresenceUI

Little software made in C# with the help of [Modern UI](https://github.com/firstfloorsoftware/mui) and [discord-rpc-csharp](https://github.com/Lachee/discord-rpc-csharp). It will start with Windows in the system tray if you configure it to do so, so it doesn't annoy you and your presence will always be displayed.
Be aware that if you play a game, it will override the presence, but as soon as you stop playing, it will display again.

![Discord Presence UI](https://i.imgur.com/rLkOMLX.png)

In order to make it work, you will need to configure an app on the [Discord Developer Portal](https://discordapp.com/developers/applications/). More informations in the `help` tab.

![Help](https://i.imgur.com/YsFbnTo.png)

# Installation

- Download the [latest release](https://github.com/hawezo/DiscordPresenceUI/releases/latest) or a [direct link](http://hawezo.legtux.org/dev/dpui/DiscordPresenceUI.zip).
- Extract the archive in `C:\Program Files\` or in your `Documents` folder.
- Create a shortcut to `DiscordPresenceUI.exe` and place it wherever you want.
- Start the `.exe` and configure it. You may refer to the `help` tab in order to understand how to use it.

# Updating

Starting off [version 2](https://github.com/hawezo/DiscordPresenceUI/tree/2.0/), the app will check for updates at startup. If an update is available, you will be asked to open a browser window to download the last release. If you do so, you will have to replace your current installation — basically, removing old files and replacing them by the new ones.
To update settings, click `Repair` in the app settings of the latest version and restart.
