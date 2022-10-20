<template>
    <div>
        <input style="display: none" type="file" @change="addFunction" ref="fileInput"/>
        <button :class="$attrs.class" class="add-btn" @click="$refs.fileInput.click"><slot></slot></button>
    </div>
</template>

<script>
export default {
    name: 'add-button',
    methods: {
        addFunction(event) {
            this.$emit('onAdd', event);
        },
    }
}
</script>

<style>
.add-btn {
    border: solid teal 2px;
    background: none;
    border-radius: 5px;
    padding: 5px;
}
.add-btn:hover {
    background-color: teal;
    color: white;
    cursor: pointer;
}
.add-btn:active {
    background-color: rgb(189, 189, 189);
    color: black;
    cursor: pointer;
}

</style>