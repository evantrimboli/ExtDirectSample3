Ext.Direct.addProvider(Sample.Remote.GridHandler);

Ext.onReady(function(){

    var store = new Ext.data.DirectStore({
        remoteSort: true,
        directFn: Sample.Grid.PagingLoad,
        paramOrder: ['sort', 'dir', 'start', 'limit'],
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
    
    var grid = new Ext.grid.GridPanel({
        renderTo: 'container',
        width: 700,
        title: 'Simple Grid with remote sorting',
        height: 400,
        store: store,
        autoExpandColumn: 'name',
        columns: [{
            header: 'Name', dataIndex: 'name', id: 'name', sortable: true
        },{
            header: 'Employees', dataIndex: 'employees', width: 100, sortable: true
        },{
            header: 'Turnover', dataIndex: 'turnover', width: 100, renderer: Ext.util.Format.usMoney, sortable: true
        },{
            header: 'Started', dataIndex: 'started', width: 150, renderer: Ext.util.Format.dateRenderer('Y-m-d'), sortable: true
        }],
        bbar: new Ext.PagingToolbar({
            store: store,
            pageSize: 3,
            displayInfo: true
        })
    });
    store.load({
      params:{
          start:0, 
          limit:3
      }
    });
    
});