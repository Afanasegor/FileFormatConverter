<template>
  <button class="download-btn" @click="downloadFunction" :disabled=isAvailable>
      <slot></slot>
  </button>
</template>

<script>
export default {
    name: 'download-button',
    props: {
        isAvailable: Boolean
    },
    methods: {
        downloadFunction() {
            this.$emit('onDownload')
        }
    }
}
</script>

<style>
.download-btn {
    border: solid teal 2px;
    background-color: rgb(228, 228, 228);
    border-radius: 5px;
    padding: 5px;
}
.download-btn:hover {
    background-color: teal;
    color: white;
    cursor: pointer;
}
.download-btn:active {
    background-color: rgb(189, 189, 189);
    color: black;
    cursor: pointer;
}
.download-btn:disabled {
    background-color: rgb(117, 117, 117);
    color: rgb(218, 218, 218);
    border: solid rgb(117, 117, 117) 2px;
    cursor: context-menu;
}

</style>