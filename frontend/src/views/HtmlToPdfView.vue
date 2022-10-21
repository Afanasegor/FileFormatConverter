<template>
  <div >
    HTML to PDF view
    <base-converter @onConvertStart="convertFileHtmlToPdf" />
    <block-divider class="block-divider" />
    <batch-list :batches="batches" @onDownloadFile="downloadFile"/>
  </div>
</template>

<script>
import RepositoryFactory from "../api-repositories/repository-factory.js";
const ConverterRepository = RepositoryFactory.get("converter");
const BatchRepository = RepositoryFactory.get("batch");

import ConverterTypeEnum from "@/enums/converter-type.js";
const HtmlToPdfType = ConverterTypeEnum.ConverterType.HtmlToPdf;

import BatchStatusesEnum from "@/enums/batch-statuses.js"
const BatchStatuses = BatchStatusesEnum.StatusesNumberToString;

import BaseConverter from "@/components/Converters/BaseConverter.vue"
import BatchList from "@/components/Batches/BatchList.vue"

export default {
  name: 'html-to-pdf-view',
  components: {
    BaseConverter,
    BatchList,
  },
  data() {
    return {
      batches: [],
      periodicTimerId: ''
    }
  },
  methods: {
    async convertFileHtmlToPdf(file) {
      const formData = new FormData();
      if (file !== null){
          formData.append('file', file, file.name);
      }
      await ConverterRepository.add(formData, HtmlToPdfType)
      .then((resp) => {console.log(resp)})
      .catch((err) => console.log(err));
    },
    async getAllBatches() {
      await BatchRepository.getAllBatches()
      .then((resp) => {
        var batches = resp.data;
        console.log('get all batches');
        // console.log(batches);
        var allBatches = [];
        for (let index = 0; index < batches.length; index++) {
          const element = batches[index];
          var batch = {
            id: element.id,
            name: element.originFileName,
            converterType: element.converterType,
            statusNumber: element.processStatus,
            statusStr:  BatchStatuses[element.processStatus],
          };
          allBatches.push(batch);
        }
        this.batches = allBatches;
      })
      .catch((err) => console.log(err));
    },
    async downloadFile(id, fileName) {
      console.log("download: " + id);
      await ConverterRepository.downloadFile(id)
      .then((resp) => {
        console.log(resp);
        const downloadFileUrl = window.URL.createObjectURL(new Blob([resp.data]));
        var fileLink = document.createElement('a');
        fileLink.href = downloadFileUrl;

        fileLink.setAttribute('download', 'converted.pdf');
        document.body.appendChild(fileLink);

        fileLink.click();
      })
      .catch((err) => console.log('error'));
    },
    makePeriodicRequestToGetAllBatches() {
      this.periodicTimerId = setInterval(async () => await this.getAllBatches(), 2000);
    },
    stopPeriodicRequestToGetAllBatches() {
      clearInterval(this.periodicTimerId);
    }
  },
  async mounted() {
    await this.getAllBatches();
    this.makePeriodicRequestToGetAllBatches();
  },
  unmounted() {
    this.stopPeriodicRequestToGetAllBatches()
  }
}
</script>

<style scoped>

.block-divider {
    margin-top: 10px;
    margin-bottom: 10px;
}

</style>