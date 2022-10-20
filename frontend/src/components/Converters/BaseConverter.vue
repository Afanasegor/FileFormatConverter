<template>
  <div>
      <div v-if="fileName">
        {{ this.fileName }}
      </div>
      <div class="add-btn-block">
          <add-button class="add-btn-size" v-if="!file" type="file" @onAdd="setFile">Выбрать файл</add-button>
          <base-button class="add-btn-size" v-else @click="clearFile">Сбросить</base-button>
      </div>
      <div class="converter-btn-block">
        <convert-button class="converter-btn-size" :isAvailable="!isConvertingAvailable" @click="startConvert">Конвертировать</convert-button>
      </div>
  </div>
</template>

<script>
export default {
    name: "base-converter",
    data() {
        return {
            file: null,
            fileName: ''
        }
    },
    methods: {
      setFile(event){
          this.file = event.target.files[0];
          this.fileName = this.file.name;
      },
      clearFile(){
          this.file = null;
          this.fileName = '';
      },
      startConvert() {
        this.$emit('onConvertStart', this.file);
        this.clearFile();
      }
    },
    computed: {
      isConvertingAvailable(){
        return this.file !== null;
      }
    }
}
</script>

<style>

.add-btn-block {
  margin-top: 10px;
}

.add-btn-size {
  min-width: 300px; 
}

.converter-btn-size {
  min-width: 300px; 
}

.converter-btn-block {
  margin-top: 10px;
}

</style>