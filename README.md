# WoWJunction

## 介绍

魔兽世界怀旧服(国服/亚服)切换器

## 原理

`软链接`（也称为符号链接），是一个特殊的目录或文件，它是虚拟的，作用是把这个虚拟的目录或文件指向另一个真实的目录或文件。

而 `Windows` 上的 `NTFS` 文件格式也是支持类似 `Linux` 上的 `软链接` 功能的，`Windows` 叫做 `Reparse Point`（重解析点），而 `NTFS` 文件格式从 `Windows 7` 开始，已经基本普及了。

我们就是利用 `软链接`，创建一个虚拟的《魔兽世界》怀旧服文件夹 `_classic_` ，把这个虚拟的文件夹指向真实的怀旧服（国服）文件夹 `_classic_cn_` 或者怀旧服（亚服）文件夹 `_classic_tw_`，来实现切换的目的。

## 操作步骤

1. 首先，把《魔兽世界》游戏以及《战网》客户端都关闭，不关闭的话，修改文件夹的名字可能会失败；
2. 进入您的魔兽世界安装目录，例如：`C:\World of Warcraft`。

**如果你之前玩的是怀旧服（亚服）**

3. 找到《魔兽世界》怀旧服的文件夹“`_classic_`”，则将其更名为“`_classic_tw_`”，它就是你真实的怀旧服（亚服）文件夹；
4. 把你更名后的这个文件夹“`_classic_tw_`”，复制一份，并粘贴到当前文件夹，并重名为“`_classic_cn_`”，这就是你真实的怀旧服（国服）文件夹；

**如果你之前玩的是怀旧服（国服）**

3. 找到《魔兽世界》怀旧服的文件夹“`_classic_`”，则将其更名为“`_classic_cn_`”，它就是你真实的怀旧服（国服）文件夹；
4. 把你更名后的这个文件夹“`_classic_cn_`”，复制一份，并粘贴到当前文件夹，并重名为“`_classic_tw_`”，这就是你真实的怀旧服（亚服）文件夹；

5. 这样你就得到“`_classic_cn_`”，“`_classic_tw_`”两个文件夹，分别代表国服和亚服游戏目录。

## 使用说明

1. xxxx
2. xxxx
3. xxxx

## 参与贡献

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request

#### 特技

1.  使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2.  Gitee 官方博客 [blog.gitee.com](https://blog.gitee.com)
3.  你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解 Gitee 上的优秀开源项目
4.  [GVP](https://gitee.com/gvp) 全称是 Gitee 最有价值开源项目，是综合评定出的优秀开源项目
5.  Gitee 官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6.  Gitee 封面人物是一档用来展示 Gitee 会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)
