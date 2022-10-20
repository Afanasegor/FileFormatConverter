<template>
  <button class="base-btn" @click="baseFunction">
      <slot></slot>
  </button>
</template>

<script>
export default {
    name: 'base-button',
    methods: {
        baseFunction() {
            this.$emit('onBase')
        }
    }
}
</script>

<style>
.base-btn {
    border: solid teal 2px;
    background: none;
    border-radius: 5px;
    padding: 5px;
}
.base-btn:hover {
    background-color: teal;
    color: white;
    cursor: pointer;
}
.base-btn:active {
    background-color: rgb(189, 189, 189);
    color: black;
    cursor: pointer;
}

</style>