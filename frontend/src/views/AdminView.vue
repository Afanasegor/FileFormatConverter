<template>
  <div class="about">
    <h1>Админ-панель</h1>
    <delete-button class="delete-btn" @onDelete="deleteAllBatches">Удалить все процессы</delete-button>
  </div>
</template>

<script>
import RepositoryFactory from "../api-repositories/repository-factory.js";
const BatchRepository = RepositoryFactory.get("batch");

export default {
  name: 'admin-view',
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
}
</style>