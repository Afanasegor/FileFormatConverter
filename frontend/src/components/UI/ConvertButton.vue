<template>
    <button class="convert-btn" @click="convertFunction" :disabled=isAvailable>
        <slot></slot>
    </button>
  
</template>

<script>
export default {
    name: 'convert-button',
    props: {
        isAvailable: Boolean
    },
    methods: {
        convertFunction() {
            this.$emit('onConvert')
        }
    }
}
</script>

<style>
.convert-btn {
    border: solid teal 2px;
    background: none;
    border-radius: 5px;
    padding: 5px;
}
.convert-btn:hover {
    background-color: teal;
    color: white;
    cursor: pointer;
}
.convert-btn:active {
    background-color: rgb(189, 189, 189);
    color: black;
    cursor: pointer;
}
.convert-btn:disabled {
    background-color: rgb(117, 117, 117);
    color: rgb(218, 218, 218);
    border: solid rgb(117, 117, 117) 2px;
    cursor: context-menu;
}

</style>