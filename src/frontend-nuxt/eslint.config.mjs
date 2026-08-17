// frontend-nuxt/eslint.config.mjs
import shared from '../eslint.shared.mjs';
import { createConfigForNuxt } from '@nuxt/eslint-config';
import tsParser from '@typescript-eslint/parser';

export default createConfigForNuxt()
  .prepend(...shared)
  .append(
    {
      files: ['**/*.vue'],
      languageOptions: {
        parserOptions: {
          parser: tsParser,
        },
        globals: {
          useFetch: 'readonly',
        },
      },
    },
    {
      files: ['server/**/*.ts'],
      languageOptions: {
        globals: {
          defineEventHandler: 'readonly',
          useRuntimeConfig: 'readonly',
        },
      },
    },
  );
