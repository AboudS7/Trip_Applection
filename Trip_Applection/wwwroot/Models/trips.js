
var Repositry = {
    GetAll: function () {
        Helper.AjaxCallGet("", {}, "json",
            function (data) {
                var htmlData = "";
                console.log(data);
            for (var i = 0; i < data.data.length; i++) {
                    htmlData += this.Repositry.DrawItem(data.data[i]);

                }
                console.log(htmlData);
                var d1 = document.getElementById('ItemArea');
                d1.innerHTML = htmlData;
            }, function () { });
    }
}