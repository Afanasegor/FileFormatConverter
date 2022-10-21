import Client from '@/api-clients/main-api-client.js';
const resource = '/converter';

export default {
    async checkStatus(batchId) {
        let apiMethod = '/check-status';
        return await Client.get(`${resource}${apiMethod}?id=${batchId}`);
    },
    async add(fileFormData, converterType){
        let apiMethod = '/convert';
        return await Client.post(`${resource}${apiMethod}?converterType=${converterType}`, fileFormData);
    },
    async downloadFile(batchId) {
        let apiMethod = '/download-converted-file';
        return await Client.request({
            url: `${resource}${apiMethod}?id=${batchId}`,
            method: "GET",
            responseType: "blob",
            })
    },
};