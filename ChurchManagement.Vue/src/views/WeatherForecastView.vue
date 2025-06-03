<template>
  <div v-if="error">
    <p>Erro: {{ error }}</p>
  </div>
  <div v-else>
    <table>
      <thead>
        <tr>
          <th>Data</th>
          <th>Temp. (C)</th>
          <th>Temp. (F)</th>
          <th>Resumo</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="forecast in forecasts" :key="forecast.date">
          <td>{{ forecast.date }}</td>
          <td>{{ forecast.temperatureC }}</td>
          <td>{{ forecast.temperatureF }}</td>
          <td>{{ forecast.summary }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

interface WeatherForecast {
  date: string
  temperatureC: number
  temperatureF: number
  summary: string
}

const forecasts = ref<WeatherForecast[]>([])
const loading = ref(true)
const error = ref<string | null>(null)

onMounted(async () => {
  try {
    const response = await fetch('api/weatherforecast')
    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.statusText}`)
    }
    const data = await response.json()
    forecasts.value = data
  } catch (err) {
    error.value = (err as Error).message
  } finally {
    loading.value = false
  }
})
</script>

<style scoped>
table {
  border: none;
  border-collapse: collapse;
}

th {
  font-size: x-large;
  font-weight: bold;
  border-bottom: solid 0.2rem hsla(160, 100%, 37%, 1);
}

th,
td {
  padding: 1rem;
}

td {
  text-align: center;
  font-size: large;
}

tr:nth-child(even) {
  background-color: var(--vt-c-black-soft);
}
</style>
