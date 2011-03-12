Ext.Direct.addProvider(Sample.Remote.FormHandler);
Ext.onReady(function(){

    var form = new Ext.form.FormPanel({
        renderTo: 'container',
        title: 'Image Upload',
        labelWidth: 150,
        bodyStyle: 'padding: 20px;',
        width: 500,
        height: 120,
        fileUpload: true,
        api: {
            submit: Sample.Form.Upload
        },
        items: {
            fieldLabel: 'Choose Image To Upload',
            xtype: 'textfield',
            inputType: 'file'
            
        },
        buttons: [{
            text: 'Upload',
            iconCls: 'icon-upload',
            handler: function(){
                form.getForm().submit({
                    waitMsg: true,
                    success: function(basicForm, action){
                        var image = action.result.image;
                        
                        var w = new Ext.Window({
                            width: 100,
                            height: 100,
                            title: 'Uploaded Image',
                            bodyCfg: {
                                src: image.path,
                                tag: 'img'
                            }
                        });
                        w.show();
                        w.setSize(image.width + w.getFrameWidth(), image.height + w.getFrameHeight());
                    },
                    failure: function(){
                        Ext.MessageBox.alert('Failure', 'No file chosen, upload failed.');
                    }
                });
            }
        }]
    });

});