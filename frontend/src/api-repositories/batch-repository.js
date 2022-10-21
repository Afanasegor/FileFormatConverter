import Client from '@/api-clients/main-api-client.js';
const resource = '/batch';

export default {
    async getAllBatches() {
        let apiMethod = '/get-all';
        return await Client.get(`${resource}${apiMethod}`);
    },
    async deleteAllBatches() {
        let apiMethod = '/delete-all';
        return await Client.delete(`${resource}${apiMethod}`);
    }
};