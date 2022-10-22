<template>
    <div class="element-with-border" :class="getStatusClass">
        <div class="origin-file-name">{{ item.name }}</div>
        <div class="status-number">{{ item.statusStr }}</div>
        <download-button class="batch-btn" :isAvailable="isDownloadAvailable" @onDownload="downloadFile">Скачать файл</download-button>
    </div>
</template>

<script>
import BatchStatusesEnum from "@/enums/batch-statuses.js";
const BatchStatuses = BatchStatusesEnum.Statuses;

export default {
    name: "batch-item",
    props: {
        item: {
            require: true
        }
    },
    data() {
        return {
            batchClass: {
                active: true,

            }
        }
    },
    methods: {
        downloadFile() {
            this.$emit('onDownload', this.item.id);
        }
    },
    computed: {
        getStatusClass() {
            return {
                'batch-btn-ready': this.item.statusNumber === BatchStatuses.Completed,
                'batch-btn-error': this.item.statusNumber === BatchStatuses.Error,
                'batch-btn-in-process': this.item.statusNumber === BatchStatuses.InProcessing,
                'batch-btn-created': this.item.statusNumber === BatchStatuses.Created
            }
        },
        isDownloadAvailable(){
            return this.item.statusNumber !== BatchStatuses.Completed;
        }
    }
}

</script>

<style>
.element-with-border {
    padding: 8px;
    display: flex;
    align-items: center;
    justify-items: center;
    min-width: 500px;
}

.batch-btn-created {
    border: 2px solid rgb(90, 90, 90);
    background-color: rgb(179, 179, 179);
}

.batch-btn-ready {
    border: 2px solid teal;
    background-color: rgb(127, 228, 166);
}

.batch-btn-error {
    border: 2px solid rgb(128, 0, 0);
    background-color: rgb(248, 169, 169);
}

.batch-btn-in-process {
    border: 2px solid rgb(119, 128, 0);
    background-color: rgb(233, 233, 136);
}

.batch-btn {
    margin-left: auto;
    align-self: center;
}

.status-number {
    margin-left: auto;
    margin-right: 20px;
    align-self: center;
}

.origin-file-name {
    justify-self: flex-start;
    width: 180px;
    align-self: center;
    text-align: start;
}
</style>