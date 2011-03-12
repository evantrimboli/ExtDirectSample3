Ext.Direct.addProvider(Sample.Remote.FormHandler);
Ext.onReady(function(){

    var form = new Ext.form.FormPanel({
        renderTo: document.body,
        width: 400,
        height: 250,
        title: 'Simple Form',
        labelWidth: 140,
        bodyStyle: 'padding: 20px;',
        paramOrder: 'company',
        api: {
            load: Sample.Form.Load,
            submit: Sample.Form.Save
        },
        items: [{
            xtype: 'textfield',
            fieldLabel: 'First Name',
            name: 'firstName'
        },{
            xtype: 'textfield',
            fieldLabel: 'Last Name',
            name: 'lastName'
        },{
            xtype: 'textfield',
            fieldLabel: 'E-Mail',
            name: 'email'
        },{
            xtype: 'datefield',
            fieldLabel: 'Expires',
            name: 'expires',
            format: 'Y-m-d'
        },{
            xtype: 'numberfield',
            fieldLabel: 'Maximum per week',
            name: 'maxEmails'
        },{
            xtype: 'checkbox',
            fieldLabel: 'Receive emails',
            name: 'receiveEmail'
        }],
        buttons: [{
            text: 'Load',
            iconCls: 'icon-load',
            handler: function(){
                form.getForm().load({
                    params: {
                        company: 'Ext',
                    },
                    success : function(){
                        form.fbar.getComponent('save').enable();
                    }
                });
            }
        },{
            itemId: 'save',
            iconCls: 'icon-save',
            text: 'Save',
            disabled: true,
            handler: function(){
                form.getForm().submit({
                    params: {
                        company: 'Ext'
                    },
                    success: function(basicForm, action){
                        var arr = [],
                            parseValue = function(prop, value){
                                if(prop == 'expires'){
                                    return value.format('Y-m-d');
                                }else if(prop == 'receiveEmail'){
                                    return value ? 'Yes' : 'No';
                                }else{
                                    return value;
                                }
                            };
                        Ext.iterate(action.result.data, function(prop, value){
                            arr.push('<b>', prop, '</b>: ', parseValue(prop, value), '<br />');
                        });
                        Ext.MessageBox.alert('Results', arr.join(''));
                    }
                });
            }
        }]
    });

});