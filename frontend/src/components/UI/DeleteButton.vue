<template>
    <button class="delete-btn" @click="deleteFunction">
        <slot></slot>
    </button> 
</template>

<script>
export default {
    name: 'delete-button',
    methods: {
        deleteFunction() {
            this.$emit('onDelete')
        }
    }
}
</script>

<style>
.delete-btn {
    border: solid rgb(128, 0, 0) 2px;
    background: none;
    border-radius: 5px;
    padding: 5px;
}
.delete-btn:hover {
    background-color: #af4c4c;
    color: white;
    cursor: pointer;
}
.delete-btn:active {
    background-color: #f70606;
    color: white;
    cursor: pointer;
}

</style>