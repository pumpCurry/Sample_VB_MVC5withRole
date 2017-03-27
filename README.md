# Sample_VB_MVC5withRole
Require: NET Framework 4.5.2,Checked on Visual Studio Express 2013 for Web.
## VB.net template MVC5 with RoleManager

http://kaz16a.hatenablog.jp/entry/2014/10/13/000843

kaz16a さんの kaz16a's blog より、2014/10/13 のエントリ、
「ASP.NET IdentityでRoleを使う手順」の VB.net MVC5対応版 です。

ファイル＞新しいプロジェクト＞ASP.NET(VB)＞MVC5 になります。
改造ポイントは上記のサイトと、以下を参考に組み込んでください。
(プロジェクト名が望んだものになっていなかったり、GUIDがかぶってしまうので、該当するファイルだけ持っていくが吉です）
Change Log: https://github.com/pumpCurry/Sample_VB_MVC5withRole/commit/0f2136c2de0c0bb414eca1a9f036ebce52041262


## TransferToAction for ASP.NET MVC 5

https://blogs.msdn.microsoft.com/riwickel/2016/03/29/transfertoaction-for-asp-net-mvc-5/

Ricardo Niepel [MSFT] さんの Ricardo's Blog より、2016/03/29 のエントリ、
「TransferToActionをVB.netで使うサンプル」 VB.net MVC5対応版 です。これをつかうと、
RedirectToActionのように、302を一度返してブラウザに飛びなおさせることなく、コントローラ名と
アクション名表示を同一に維持したまま違うアクションに飛ばすことができます。
例えばLoginさせたいとき、トップにRedirectで飛ばした後 実態は ~/Account/Login/ に投げなおして 
/Login みたいなダサいURIを避ける、みたいな使い方とかできますね。
Change Log: https://github.com/pumpCurry/Sample_VB_MVC5withRole/commit/36437ca9ae1030c3da6b95b7ea125aca80a34748


ぱんかれでした
