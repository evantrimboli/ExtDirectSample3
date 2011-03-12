Ext.Direct.addProvider(Sample.Remote.EchoHandler);
Ext.onReady(function(){
    var form = new Ext.form.FormPanel({
        renderTo: 'container',
        bodyStyle: 'padding: 20px;',
        width: 400,
        height: 400,
        title: 'Sum',
        items: [{
            fieldLabel: 'Number A',
            itemId: 'a',
            xtype: 'numberfield',
            value: 0
        },{
            fieldLabel: 'Number B',
            itemId: 'b',
            xtype: 'numberfield',
            value: 0
        }],
        buttons: [{
            text: 'Add',
            iconCls: 'icon-sum',
            handler: function(){
                var a = form.getComponent('a').getValue(),
                    b = form.getComponent('b').getValue();
                    
                Sample.Echo.Sum(a, b, function(data, trans){
                    console.log(arguments);
                    // clear anything from the previous request
                    form.remove('label');
                    form.add({
                        itemId: 'label',
                        xtype: 'label',
                        html: String.format('{0} + {1} = <b>{2}</b>', a, b, data)
                    });
                    form.doLayout();
                    form.getComponent('label').getEl().highlight();
                });                
            }
        }]
    });
});