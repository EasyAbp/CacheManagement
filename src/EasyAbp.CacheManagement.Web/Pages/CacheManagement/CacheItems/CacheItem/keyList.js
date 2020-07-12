$(function () {

    var l = abp.localization.getResource('EasyAbpCacheManagement');
    var detailModal = new abp.ModalManager(abp.appPath + 'CacheManagement/CacheItems/CacheItem/DetailModal');

    var service = easyAbp.cacheManagement.cacheItems.cacheItem;

    var dataTable = $('#CacheItemTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        bPaginate: false,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getKeys, function () {
            return cacheItemId;
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Detail'),
                                action: function (data) {
                                    detailModal.open({ cacheItemId:data.record.cacheItemId, cacheKey: data.record.cacheKey });
                                }
                            },
                            {
                                text: l('ClearCache'),
                                visible: abp.auth.isGranted('EasyAbp.CacheManagement.CacheItem.ClearCache'),
                                confirmMessage: function (data) {
                                    return l('ClearCacheConfirmationMessage', data.record.cacheKey);
                                },
                                action: function (data) {
                                    service.clearSpecific({
                                        cacheItemId: data.record.cacheItemId,
                                        cacheKey: data.record.cacheKey
                                    })
                                    .then(function () {
                                        abp.notify.info(l('SuccessCleared'));
                                        dataTable.ajax.reload();
                                    });
                                }
                            }
                        ]
                }
            },
            { data: "cacheKey", width: "10%" },
        ]
    }));

    $('#ClearAllCacheButton').click(function (e) {
        e.preventDefault();
        abp.message.confirm(l('ClearAllCacheConfirmationMessage'), l('ClearAllCache'))
            .done(function (accepted) {
                if (accepted) {
                    service.clear({ cacheItemId: cacheItemId}).done(function () {
                        abp.notify.info(l('SuccessCleared'));
                    })
                }
            });
    });
});