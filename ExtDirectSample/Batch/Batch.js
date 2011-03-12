Ext.Direct.addProvider(Sample.Remote.BatchHandler);
Ext.onReady(function(){
    
    var p = new Ext.Panel({
        renderTo: 'container',
        title: 'System Information',
        width: 400,
        height: 300,
        bodyStyle: 'padding: 5px;',
        tbar: [{
            iconCls: 'icon-load',
            text: 'Load Info',
            handler: function(){
                var b = Sample.Batch,
                    content = [],
                    cnt = 0,
                    doUpdate = function(){
                        ++cnt;
                        if(cnt >= 4){
                            p.body.update(content.join('<br />'));
                        }
                    };
                    
                b.GetMachineName(function(data){
                    content.push('<b>Machine Name: </b>' + data);
                    doUpdate();
                });
                b.GetVersion(function(data){
                    content.push('<b>Framework Version: </b>' + data);
                    doUpdate();
                });
                b.GetProcessorCount(function(data){
                    content.push('<b>Processor Count: </b>' + data);
                    doUpdate();
                });
                b.GetUserName(function(data){
                    content.push('<b>User Name: </b>' + data);
                    doUpdate();
                });
            }
        }]
    });

});