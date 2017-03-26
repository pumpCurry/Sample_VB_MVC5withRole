﻿@ModelType ManageLoginsViewModel
@Imports Microsoft.Owin.Security
@Imports Microsoft.AspNet.Identity
@Code
    ViewBag.Title = "外部ログインの管理"
End Code

<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
    If loginProviders.Count = 0 Then
        @<div>
            <p>
                構成済みの外部認証サービスはありません。外部サービス経由のログインをサポートするようにこの ASP.NET アプリケーションを設定する方法の
                詳細については、<a href="http://go.microsoft.com/fwlink/?LinkId=313242">こちらの記事</a>をご覧ください。
            </p>
        </div>
    Else
        If Model.CurrentLogins.Count > 0  Then
            @<h4>登録済みのログイン</h4>
            @<table class="table">
                <tbody>
                    @For Each account As UserLoginInfo In Model.CurrentLogins
                        @<tr>
                            <td>@account.LoginProvider</td>
                            <td>
                                @If ViewBag.ShowRemoveButton
                                    @Using Html.BeginForm("RemoveLogin", "Manage")
                                        @Html.AntiForgeryToken()
                                        @<div>
                                            @Html.Hidden("loginProvider", account.LoginProvider)
                                            @Html.Hidden("providerKey", account.ProviderKey)
                                            <input type="submit" class="btn btn-default" value="削除" title="この @account.LoginProvider ログインをアカウントから削除します" />
                                        </div>
                                    End Using
                                Else
                                    @: &nbsp;
                                End If
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
        If Model.OtherLogins.Count > 0
            @<text>
            <h4>ログインのための別のサービスを追加します。</h4>
            <hr />
            </text>
            @Using Html.BeginForm("LinkLogin", "Manage")
                @Html.AntiForgeryToken()
                @<div id="socialLoginList">
                <p>
                    @For Each p As AuthenticationDescription In Model.OtherLogins
                        @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="@p.Caption アカウントを使用してログイン">@p.AuthenticationType</button>
                    Next
                </p>
                </div>
            End Using
        End If
    End If
End Code
