<template>
  <div class="home home-page">
    <h3>Hello and welcome to File Converter Service :D</h3>
    <div>
      <router-link to="/html-to-pdf">
        <img class="converter-image" alt="HTML to PDF converter image" src="../assets/HTML-to-PDF.png" >
      </router-link>
    </div>
    <h3 style="margin-top: 20px;">Stack:</h3>
    <div class="stack-list">
      <img class="stack-image" alt="ASP .NET Core logo" src="../assets/asp-net-core-logo.png">
      <img class="stack-image" alt="Vue logo" src="../assets/logo.png">
      <img class="stack-image" alt="Puppeter logo" src="../assets/puppeter-logo.png">
      <img class="stack-image" alt="Hangfire logo" src="../assets/hangfire-logo.png">
    </div>
    <!-- <hello-world msg="Welcome to Your Vue.js App"/> -->
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'home-view',
  components: {
    HelloWorld
  }
}
</script>

<style scoped>

.home-page {
  display: flex; 
  flex-direction: column;
  align-content: center;
  flex-wrap: wrap;
}

.converter-image {
  margin-top: 10px;
  border: gray 4px solid;
  border-radius: 20px;
  height: 150px;
}

.converter-image:hover {
  border: rgb(180, 180, 180) 4px solid;
  background-color: rgb(180, 180, 180);
}

.stack-list {
  display: flex;
  justify-content: center;
  height: 80px;
  margin-top: 10px;
}

.stack-image{
  height: 60px;
  margin-right: 5px;
  margin-left: 5px;
}
</style>