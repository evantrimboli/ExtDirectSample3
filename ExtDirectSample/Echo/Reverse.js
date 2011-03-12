Ext.Direct.addProvider(Sample.Remote.EchoHandler);
Ext.onReady(function(){
    var form = new Ext.form.FormPanel({
        renderTo: 'container',
        hideLabels: true,
        bodyStyle: 'padding: 20px;',
        width: 400,
        height: 150,
        title: 'Reverse',
        items: {
            itemId: 'input',
            xtype: 'textfield',
            value: 'Foo'
        },
        buttons: [{
            text: 'Reverse',
            iconCls: 'icon-reverse',
            handler: function(){
                var input = form.getComponent('input').getValue();
                Sample.Echo.Reverse(input, function(data, trans){
                    // clear anything from the previous request
                    form.remove('label');
                    form.add({
                        itemId: 'label',
                        xtype: 'label',
                        html: String.format('{0} reversed is <b>{1}</b>', input, data)
                    });
                    form.doLayout();
                    form.getComponent('label').getEl().highlight();
                });                
            }
        }]
    });
});