# WoWJunction

| [中文版](./README.md) | [English Version](./README.en.md) |

## 简介

魔兽世界怀旧服(国服/亚服)切换器 （WoWJunction）

## 原理

`软链接`（也称为 `符号链接`），是一个特殊的目录或文件，它是虚拟的，作用是把这个虚拟的目录或文件指向另一个真实的目录或文件。

而 `Windows` 上的 `NTFS` 文件格式也是支持类似 `Linux` 上的 `软链接` 功能的，`Windows` 叫做 `Reparse Point`（重解析点），而 `NTFS` 文件格式从 `Windows 7` 开始，已经基本普及了。

我们利用 `软链接` 功能，创建一个虚拟的《魔兽世界》怀旧服文件夹 `_classic_` ，让这个虚拟的文件夹指向真实的怀旧服（国服）文件夹 `_classic_cn_` 或者怀旧服（亚服）文件夹 `_classic_tw_`，来实现切换的目的。

## 软件名

`Windows` 上 `微软` 官方做一个管理目录软链接的工具 [Junction](https://learn.microsoft.com/zh-cn/sysinternals/downloads/junction)，中文叫 `交接点`，这也是本软件名 `WoWJunction` 的由来。本程序最早的代码，也是从搜索 “`微软 Junction`” 开始的，`codeproject` 上有人分享了一份源码：[Manipulating NTFS Junction Points in .NET](https://www.codeproject.com/Articles/15633/Manipulating-NTFS-Junction-Points-in-NET)，这是这个软件的核心代码。

## 依赖库

本软件是基于微软的 `.Net Framework v4.5.2`，采用 `C#` 编写的。在 `Windows 7` 或后续的 `Windows` 版本应该都已经自带了，如果运行时显示需要安装 `.Net Framework`，请自行百度搜索最新版的 `.Net Framework`安装即可，要求是版本要大于或等于 `v4.5.2`。

本人是 `C++` 程序员，原则上可以用 `C++` 重写该软件，但由于用 `C++` 重写需要耗费的时间比较长，如无特殊需求，就不重写了。有人出资，或者哪天我有兴致又有时间的话，会考虑。

## 设置步骤

1. 首先，把《魔兽世界》游戏以及《战网》客户端都关闭，不关闭的话，修改文件夹名可能会失败；
2. 进入您的魔兽世界安装目录，例如：`C:\World of Warcraft`。

    * **如果你之前玩的是怀旧服（亚服）**

        1. 找到《魔兽世界》怀旧服的文件夹“`_classic_`”，则将其更名为“`_classic_tw_`”，它就是你真实的怀旧服（亚服）文件夹；
        2. 把你更名后的这个文件夹“`_classic_tw_`”，复制一份，并粘贴到当前文件夹，并重名为“`_classic_cn_`”，这就是你真实的怀旧服（国服）文件夹；

    * **如果你之前玩的是怀旧服（国服）**

        1. 找到《魔兽世界》怀旧服的文件夹“`_classic_`”，则将其更名为“`_classic_cn_`”，它就是你真实的怀旧服（国服）文件夹；
        2. 把你更名后的这个文件夹“`_classic_cn_`”，复制一份，并粘贴到当前文件夹，并重名为“`_classic_tw_`”，这就是你真实的怀旧服（亚服）文件夹；

3. 这样你就得到“`_classic_cn_`”，“`_classic_tw_`”两个文件夹，分别代表国服和亚服游戏目录。其中 `cn` 是中国的缩写，代表国服；`tw` 是台湾的缩写，代表亚服/台服。

## 使用说明

1. xxxx
2. xxxx
3. xxxx

## 参与贡献

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request

## 特技

1. 使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2. Gitee 官方博客 [blog.gitee.com](https://blog.gitee.com)
3. 你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解 Gitee 上的优秀开源项目
4. [GVP](https://gitee.com/gvp) 全称是 Gitee 最有价值开源项目，是综合评定出的优秀开源项目
5. Gitee 官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6. Gitee 封面人物是一档用来展示 Gitee 会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)
