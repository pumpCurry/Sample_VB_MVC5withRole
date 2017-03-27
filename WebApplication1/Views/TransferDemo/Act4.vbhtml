@Code
    ViewData("Title") = "Destination: ~/" & ViewData("Controller") & "/" & ViewData("Action") & "/" & ViewData("ID")
End Code

<h2>@ViewData("Title").</h2>
<h4>0:@ViewData("Message0")</h4>
<h4>1:@ViewData("Message1")</h4>
<h4>2:@ViewData("Message2")</h4>
<h4>3:@ViewData("Message3")</h4>
<h4>4:@ViewData("Message4")</h4>

<p>This is TransferToAction DEMO.</p>

<ul>
    <li>@(Html.ActionLink(linkText:="[→ Return to TransferToAction Demo INDEX]", _
                    controllerName:="TransferDemo", _
                        actionName:="Index", _
                       routeValues:=Nothing, _
                    htmlAttributes:=Nothing _
    ))</li>
</ul>