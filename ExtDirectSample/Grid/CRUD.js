Ext.Direct.addProvider(Sample.Remote.GridHandler);

Ext.onReady(function(){
    var store = new Ext.data.DirectStore({
        autoLoad: true,
        autoSave: true,
        remoteSort: true,
        api: {
            create: Sample.Grid.Create,
            read: Sample.Grid.Load,
            update: Sample.Grid.Update,
            destroy: Sample.Grid.Destroy
        },
        writer: new Ext.data.JsonWriter({
            encode: false,
            writeAllFields: true
        }),
        paramOrder: ['sort', 'dir'],
        idProperty: 'id',
        totalProperty: 'total',
        root: 'data',
        sortInfo: {
            field: 'name',
            direction: 'ASC'
        },
        fields: [{
            type: 'int',
            name: 'id'
        }, 'name', {
            type: 'int',
            name: 'employees'
        },{
            type: 'float',
            name: 'turnover'
        },{
            type: 'date',
            name: 'started',
            dateFormat: 'c'
        }]
    });
    
    var grid = new Ext.grid.EditorGridPanel({
        renderTo: 'container',
        width: 700,
        title: 'Simple CRUD Grid with remote sorting',
        height: 400,
        store: store,
        autoExpandColumn: 'name',
        selModel: new Ext.grid.RowSelectionModel({
            singleSelect: true,
            listeners: {
                selectionchange: function(sm){
                    var disabled = sm.getSelected() == null,
                        tb = grid.getTopToolbar();
                        
                    tb.getComponent('remove').setDisabled(disabled);
                }
            }
        }),
        columns: [{
            header: 'Name', dataIndex: 'name', id: 'name', sortable: true, editor: new Ext.form.TextField()
        },{
            header: 'Employees', dataIndex: 'employees', width: 100, sortable: true
        },{
            header: 'Turnover', dataIndex: 'turnover', width: 100, renderer: Ext.util.Format.usMoney, sortable: true
        },{
            header: 'Started', dataIndex: 'started', width: 150, renderer: Ext.util.Format.dateRenderer('Y-m-d'), sortable: true
        }],
        tbar: [{
            itemId: 'remove',
            disabled: true,
            text: 'Remove',
            iconCls: 'icon-remove',
            disabled: true,
            handler: function(){
                var rec = grid.getSelectionModel().getSelected();
                store.remove(rec);
            }
        },{
            iconCls: 'icon-add',
            text: 'Create',
            handler: function(){
                var win = new Ext.Window({
                    width: 400,
                    height: 400,
                    layout: 'fit',
                    title: 'Create Company',
                    items: {
                        xtype: 'form',
                        bodyStyle: 'padding: 10px;',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: 'Name',
                            name: 'name'
                        },{
                            xtype: 'numberfield',
                            fieldLabel: 'Employees',
                            name: 'employees',
                            allowDecimals: false,
                            allowNegative: false
                        },{
                            xtype: 'numberfield',
                            fieldLabel: 'Turnover',
                            name: 'turnover',
                            allowDecimals: true,
                            allowNegative: false
                        },{
                            xtype: 'datefield',
                            fieldLabel: 'Started',
                            name: 'started',
                            format: 'Y-m-d'
                        }]
                    },
                    buttons: [{
                        text: 'Save',
                        handler: function(){
                            var Company = store.recordType,
                                values = win.items.first().getForm().getValues();
                                
                            console.log(values);
                            store.add(new Company({
                                name: values.name,
                                employees: values.employees,
                                turnover: values.turnover,
                                started: new Date.parseDate(values.started, 'Y-m-d')
                            }));
                            win.destroy();
                        }
                    },{
                        text: 'Cancel',
                        handler: function(){
                            win.destroy();
                        }
                    }]
                });
                win.show();
            }
        },{
            iconCls: 'icon-load',
            text: 'Reload grid data to initial state',
            handler: function(){
                Sample.Grid.ResetDB(function(){
                    store.reload();
                });
            }
        }]
    });
    
});