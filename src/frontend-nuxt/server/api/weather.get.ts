import type { WeatherForecast } from '@mojoprototype/frontend-core/src';

export default defineEventHandler(async () => {
  const config = useRuntimeConfig();

  return $fetch<WeatherForecast[]>('/api/weather', { baseURL: config.apiUrl });
});
