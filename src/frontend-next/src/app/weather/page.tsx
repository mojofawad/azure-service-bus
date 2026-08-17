import type { WeatherForecast } from '@mojoprototype/frontend-core/src';

export default async function Page() {
  const res = await fetch(`${process.env.API_URL}/api/weather`, {
    cache: 'no-store',
  });

  if (!res.ok) {
    throw new Error(`Failed to fetch forecast: ${res.status}`);
  }

  const forecast: WeatherForecast[] = await res.json();

  return (
    <ul>
      {forecast.map((day) => (
        <li key={day.date}>
          {day.date}: {day.temperatureC}°C / {day.temperatureF}°F —{' '}
          {day.summary}
        </li>
      ))}
    </ul>
  );
}
