<template>
    <div class="element-with-border" :class="getStatusClass">
        <div>{{ item.name }}</div>
        <div class="status-number">{{ item.statusStr }}</div>
        <download-button class="batch-btn" :isAvailable="isDownloadAvailable" @onDownload="downloadFile">Скачать файл</download-button>
    </div>
</template>

<script>

export default {
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
            console.log('button' + this.item.id)
            this.$emit('onDownload', this.item.id);
        }
    },
    computed: {
        getStatusClass() {
            return {
                'batch-btn-ready': this.item.statusNumber === 3,
                'batch-btn-error': this.item.statusNumber === 2,
                'batch-btn-in-process': this.item.statusNumber === 1,
                'batch-btn-created': this.item.statusNumber === 0
            }
        },
        isDownloadAvailable(){
            return this.item.statusNumber !== 3;
        }
    }
}

</script>

<style>
.element-with-border {
    padding: 8px;
    display: flex;
    align-items: center;
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
    align-self: flex-end;
}

.status-number {
    margin-left: auto;
    margin-right: 20px;
}
</style>