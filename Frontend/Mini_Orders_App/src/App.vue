<script setup lang="ts">
import OrderList from './components/OrderList.vue';

</script>

<template>
  <header class="flex flex-row">
    <div class="bg-[#2E4B45] flex-1 text-[white] flex flex-row justify-center p-[1em] shadow-[0px_0px_20px_0px_#2E4B45]">
      <h2 class="text-[2em] font-bold tracking-[1.1px]">Mini Orders App</h2>
    </div>
  </header>
  <section class="w-[90vw] shadow-[0px_0px_20px_0px_#D1D1D1] mt-[1.8em] mb-0 mx-auto rounded-[25px] h-[80vh] overflow-hidden">
    <div>
        <OrderList />
    </div>
  </section>
</template>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&display=swap');
h2 {
  font-family: "Nunito Sans",helvetica;
}
header {
  scrollbar-width: thin;
}
</style>
