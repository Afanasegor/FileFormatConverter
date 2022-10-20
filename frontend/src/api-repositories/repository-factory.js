import ConverterRepository from './converter-repository.js';
import BatchRepository from './batch-repository.js';

const repositories = {
    'converter': ConverterRepository,
    'batch': BatchRepository
}
export default {
    get: name => repositories[name]
};