var pageModel;
function InitializeModel(modelJson) {
    if (JSON && JSON.parse)
        pageModel = JSON.parse(modelJson);
}

function PersistModelToHost() {
    if (pageModel && JSON && JSON.stringify)
        return JSON.stringify(pageModel);
}