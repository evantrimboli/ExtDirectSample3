Ext.Direct.addProvider(Sample.Remote.EchoHandler);
Ext.onReady(function(){
    var panel = new Ext.Panel({
        renderTo: 'container',
        width: 400,
        height: 200,
        bodyStyle: 'padding: 5px;',
        title: 'Current Time',
        tools: [{
            id: 'refresh',
            handler: function(){
                Sample.Echo.GetDate(function(data, trans){
                    var s = String.format('The current date/time is: <b>{0}</b>', data.format('Y-m-d H:s'));
                    panel.body.update(s);
                });
            }
        }]
    });
});