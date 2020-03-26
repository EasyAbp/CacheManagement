$(function () {

    var l = abp.localization.getResource('CacheManagement');
    var detailModal = new abp.ModalManager(abp.appPath + 'CacheManagement/CacheItems/CacheItem/DetailModal');

    var service = easyAbp.cacheManagement.cacheItems.cacheItem;

    var dataTable = $('#CacheItemTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        bPaginate: false,
        searching: false,
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
            { data: "cacheKey" },
        ]
    }));
});