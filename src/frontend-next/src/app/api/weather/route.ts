import { NextResponse } from 'next/server';
import type { WeatherForecast } from '@mojoprototype/frontend-core/src';

export async function GET() {
  const res = await fetch(`${process.env.API_URL}/api/weather`);

  if (!res.ok) {
    return NextResponse.json(
      { error: 'Failed to fetch forecast' },
      { status: res.status },
    );
  }

  const forecast: WeatherForecast[] = await res.json();

  return NextResponse.json(forecast);
}
