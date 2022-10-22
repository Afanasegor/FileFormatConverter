<template>
  <div class="about">
    <h1>Админ-панель</h1>
    <div style="margin-bottom: 10px;">
      <delete-button class="delete-btn" @onDelete="deleteAllBatches">Удалить все процессы</delete-button>
    </div>
    <block-divider />
    <h3 style="margin-top: 10px;">Ссылки</h3>
    <div class="link-box">
      <a class="link-to-resources" :href="swaggerLink" target=”_blank”>SWAGGER</a>
      <a class="link-to-resources" :href="hangfireLink" target=”_blank”>HANGFIRE</a>
      <a class="link-to-resources" :href="githubLink" target=”_blank”>GITHUB</a>
    </div>
    
  </div>
</template>

<script>
import RepositoryFactory from "../api-repositories/repository-factory.js";
const BatchRepository = RepositoryFactory.get("batch");

export default {
  name: 'admin-view',
  data() {
    return {
      swaggerLink: `http://${process.env.VUE_APP_API_DOMAIN}:${process.env.VUE_APP_API_PORT}/swagger`,
      hangfireLink: `http://${process.env.VUE_APP_API_DOMAIN}:${process.env.VUE_APP_API_PORT}/hangfire`,
      githubLink: "https://github.com/Afanasegor/FileFormatConverter"
    }
  },
  methods: {
    async deleteAllBatches() {
      await BatchRepository.deleteAllBatches()
      .then((resp) => console.log('Deleted all batches'))
      .catch((err) => console.log('error, when tried to delete all batches'));
    }
  }
}

</script>

<style scoped>

.delete-btn {
  margin-top: 20px;
  margin-bottom: 20px;
}

.link-box {
  height: 30px;
  margin-top: 30px;
}

.link-to-resources {
  background-color: rgb(124, 201, 190);
  color: white;
  padding: 10px 15px;
  text-decoration: none;
  text-transform: uppercase;
  margin-left: 4px;
  margin-right: 4px;
  border: black solid 2px;
  border-radius: 20px;
}
</style>