<template>
    <div>
        <h3 class="list-of-batches-header">Список процессов / файлов</h3>
        <div class="list-of-batches" v-if="batches.length > 0">
            <div v-for="item in batches" v-bind:key="item.id">
                <batch-item class="batch-item-parameters" :item="item" @onDownload="downloadFileById" />
            </div>
        </div>
        <div v-else>
            <p>Список процессов пустой...</p>
        </div>
    </div>
</template>

<script>
import BatchItem from './BatchItem.vue'

export default {
    name: "batch-list",
    components: {
        BatchItem
    },
    props: {
        batches: [Array]
    },
    methods: {
        downloadFileById(id){
            this.$emit("onDownloadFile", id);
        }
    }
}
</script>

<style>
.list-of-batches-header {
    margin-top: 20px;
}

.list-of-batches {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.batch-item-parameters {
    border-radius: 10px;
    margin-top: 15px;
    width: 300px;
}
</style>