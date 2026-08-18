<script setup lang="ts">
import type { WeatherForecast } from '@mojoprototype/frontend-core/src';

const { data: forecast, error } =
  await useFetch<WeatherForecast[]>('/api/weather');
</script>

<template>
  <div v-if="error">Failed to load forecast</div>
  <ul v-else>
    <li v-for="day in forecast" :key="day.date">
      {{ day.date }}: {{ day.temperatureC }}°C / {{ day.temperatureF }}°F -
      {{ day.summary }}
    </li>
  </ul>
</template>
